using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class Node<T> : IEqualityComparer, IEnumerable<T>, IEnumerable<Node<T>>
    {
        public Node<T> Parent { get; private set; }
        public T Value { get; set; }
        public Node<T> TempNode { get; private set; } = null;
        private readonly List<Node<T>> _children = new List<Node<T>>();
        public Node(T value)
        {
            Value = value;
        }
        public Node<T> this[int index]
        {
            get => _children[index];
        }

        public Node<T> Add(T value, int index = -1)
        {
            var childNode = new Node<T>(value);
            Add(childNode, index);
            return childNode;
        }

        public string UpdateTempNode(Node<T> node)
        {
            TempNode = node;
            return string.Empty;
        }

        public void Add(Node<T> childNode, int index = -1)
        {
            if (index < -1) throw new ArgumentException("The index can not be lower then -1");
            if (index > Children.Count() - 1)
                throw new ArgumentException("The index ({0}) can not be higher then index of the last iten. Use the AddChild() method without an index to add at the end".FormatInvariant(index));
            if (!childNode.IsRoot)
                throw new ArgumentException("The child node with value [{0}] can not be added because it is not a root node.".FormatInvariant(childNode.Value));

            if (Root == childNode)
                throw new ArgumentException("The child node with value [{0}] is the rootnode of the parent.".FormatInvariant(childNode.Value));

            if (childNode.SelfAndDescendants.Any(n => this == n))
                throw new ArgumentException("The childnode with value [{0}] can not be added to itself or its descendants.".FormatInvariant(childNode.Value));
            childNode.Parent = this;
            if (index == -1) _children.Add(childNode);
            else _children.Insert(index, childNode);
        }

        public Node<T> AddFirstChild(T value)
        {
            var childNode = new Node<T>(value);
            AddFirstChild(childNode);
            return childNode;
        }

        public void AddFirstChild(Node<T> childNode) => Add(childNode, 0);

        public Node<T> AddFirstSibling(T value)
        {
            var childNode = new Node<T>(value);
            AddFirstSibling(childNode);
            return childNode;
        }

        public void AddFirstSibling(Node<T> childNode) => Parent.AddFirstChild(childNode);

        public Node<T> AddLastSibling(T value)
        {
            var childNode = new Node<T>(value);
            AddLastSibling(childNode);
            return childNode;
        }

        public void AddLastSibling(Node<T> childNode) => Parent.Add(childNode);

        public Node<T> AddParent(T value)
        {
            var newNode = new Node<T>(value);
            AddParent(newNode);
            return newNode;
        }

        public void AddParent(Node<T> parentNode)
        {
            if (!IsRoot)
                throw new ArgumentException("This node [{0}] already has a parent".FormatInvariant(Value), "parentNode");
            parentNode.Add(this);
        }

        public IEnumerable<Node<T>> Ancestors
        {
            get
            {
                if (IsRoot) return Enumerable.Empty<Node<T>>();
                return Parent.ToIEnumarable().Concat(Parent.Ancestors);
            }
        }

        public IEnumerable<Node<T>> Descendants
        {
            get => SelfAndDescendants.Skip(1);
        }

        public IEnumerable<Node<T>> Children
        {
            get => _children;
        }

        public IEnumerable<Node<T>> Siblings
        {
            get => SelfAndSiblings.Where(Other);
        }
        private bool Other(Node<T> node) => !ReferenceEquals(node, this);

        public IEnumerable<Node<T>> SelfAndChildren
        {
            get => this.ToIEnumarable().Concat(Children);
        }

        public IEnumerable<Node<T>> SelfAndAncestors
        {
            get => this.ToIEnumarable().Concat(Ancestors);
        }

        public IEnumerable<Node<T>> SelfAndDescendants
        {
            get => this.ToIEnumarable().Concat(Children.SelectMany(c => c.SelfAndDescendants));
        }

        public IEnumerable<T> Flatten() => new[] { Value }.Union(_children.SelectMany(x => x.Flatten()));

        public IEnumerable<Node<T>> SelfAndSiblings
        {
            get
            {
                if (IsRoot) return this.ToIEnumarable();
                return Parent.Children;
            }
        }

        public IEnumerable<Node<T>> All
        {
            get => Root.SelfAndDescendants;
        }

        public IEnumerable<Node<T>> SameLevel
        {
            get => SelfAndSameLevel.Where(Other);
        }

        public int Level
        {
            get => Ancestors.Count();
        }

        public IEnumerable<Node<T>> SelfAndSameLevel
        {
            get => GetNodesAtLevel(Level);
        }

        public IEnumerable<Node<T>> GetNodesAtLevel(int level)
        {
            return Root.GetNodesAtLevelInternal(level);
        }

        private IEnumerable<Node<T>> GetNodesAtLevelInternal(int level)
        {
            if (level == Level) return this.ToIEnumarable();
            return Children.SelectMany(c => c.GetNodesAtLevelInternal(level));
        }

        public Node<T> Root
        {
            get => SelfAndAncestors.Last();
        }

        public void Disconnect()
        {
            if (IsRoot)
                throw new InvalidOperationException("The root node [{0}] can not get disconnected from a parent.".FormatInvariant(Value));
            Parent._children.Remove(this);
            Parent = null;
        }

        public bool IsRoot
        {
            get => Parent == null;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => _children.Values().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _children.GetEnumerator();

        public IEnumerator<Node<T>> GetEnumerator() => _children.GetEnumerator();

        public override string ToString() => Value.ToString();

        public static IEnumerable<Node<T>> CreateTree<TId>(IEnumerable<T> values, Func<T, TId> idSelector, Func<T, TId?> parentIdSelector)
            where TId : struct
        {
            var valuesCache = values.ToList();
            if (!valuesCache.Any())
                return Enumerable.Empty<Node<T>>();
            T itemWithIdAndParentIdIsTheSame = valuesCache.FirstOrDefault(v => IsSameId(idSelector(v), parentIdSelector(v)));
            if (itemWithIdAndParentIdIsTheSame != null) // Hier verwacht je ook een null terug te kunnen komen
                throw new ArgumentException("At least one value has the samen Id and parentId [{0}]".FormatInvariant(itemWithIdAndParentIdIsTheSame));
            var nodes = valuesCache.Select(v => new Node<T>(v));
            return CreateTree(nodes, idSelector, parentIdSelector);
        }

        public static IEnumerable<Node<T>> CreateTree<TId>(IEnumerable<Node<T>> rootNodes, Func<T, TId> idSelector, Func<T, TId?> parentIdSelector)
            where TId : struct

        {
            var rootNodesCache = rootNodes.ToList();
            var duplicates = rootNodesCache.Duplicates(n => n).ToList();
            if (duplicates.Any())
                throw new ArgumentException("One or more values contains {0} duplicate keys. The first duplicate is: [{1}]".FormatInvariant(duplicates.Count, duplicates[0]));
            foreach (var rootNode in rootNodesCache)
            {
                var parentId = parentIdSelector(rootNode.Value);
                var parent = rootNodesCache.FirstOrDefault(n => IsSameId(idSelector(n.Value), parentId));

                if (parentId.ToString().Trim().ToLower() == "00000000-0000-0000-0000-000000000000" || parentId.ToString().Trim() == "0")
                    parentId = null;

                if (parent != null)
                    parent.Add(rootNode);
                //else if (parentId != null)
                //{
                //    throw new ArgumentException("A value has the parent ID [{0}] but no other nodes has this ID".FormatInvariant(parentId.Value));
                //}
            }
            var result = rootNodesCache.Where(n => n.IsRoot);
            return result;
        }

        private static bool IsSameId<TId>(TId id, TId? parentId)
            where TId : struct
        {
            return parentId != null && id.Equals(parentId.Value);
        }

        #region Equals en ==

        public static bool operator ==(Node<T> value1, Node<T> value2)
        {
            if ((object)(value1) == null && (object)value2 == null)
                return true;
            return ReferenceEquals(value1, value2);
        }

        public static bool operator !=(Node<T> value1, Node<T> value2)
        {
            return !(value1 == value2);
        }

        public override bool Equals(Object anderePeriode)
        {
            var valueThisType = anderePeriode as Node<T>;
            return this == valueThisType;
        }

        public bool Equals(Node<T> value)
        {
            return this == value;
        }

        public bool Equals(Node<T> value1, Node<T> value2)
        {
            return value1 == value2;
        }

        bool IEqualityComparer.Equals(object value1, object value2)
        {
            var valueThisType1 = value1 as Node<T>;
            var valueThisType2 = value2 as Node<T>;

            return Equals(valueThisType1, valueThisType2);
        }

        public int GetHashCode(object obj)
        {
            return GetHashCode(obj as Node<T>);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        public int GetHashCode(Node<T> value)
        {
            return base.GetHashCode();
        }

        #endregion Equals en ==
    }

    public static class NodeExtensions
    {
        public static IEnumerable<T> Values<T>(this IEnumerable<Node<T>> nodes)
        {
            return nodes.Select(n => n.Value);
        }
    }

    public static class OtherExtensions
    {
        public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var grouped = source.GroupBy(selector);
            var moreThen1 = grouped.Where(i => i.IsMultiple());

            return moreThen1.SelectMany(i => i);
        }

        public static bool IsMultiple<T>(this IEnumerable<T> source)
        {
            var enumerator = source.GetEnumerator();
            return enumerator.MoveNext() && enumerator.MoveNext();
        }

        public static IEnumerable<T> ToIEnumarable<T>(this T item)
        {
            yield return item;
        }

        public static string FormatInvariant(this string text, params object[] parameters)
        {
            return string.Format(CultureInfo.InvariantCulture, text, parameters);
        }
    }


    public class TreeNodeModel<T>
        where T : class
    {
        public float X { get; set; }
        public int Y { get; set; }
        public float Mod { get; set; }
        public TreeNodeModel<T> Parent { get; set; }
        public List<TreeNodeModel<T>> Children { get; set; }

        public float Width { get; set; }
        public int Height { get; set; }

        public T Item { get; set; }

        public TreeNodeModel(T item, TreeNodeModel<T> parent)
        {
            this.Item = item;
            this.Parent = parent;
            this.Children = new List<TreeNodeModel<T>>();
        }

        public bool IsLeaf()
        {
            return this.Children.Count == 0;
        }

        public bool IsLeftMost()
        {
            if (this.Parent == null)
                return true;

            return this.Parent.Children[0] == this;
        }

        public bool IsRightMost()
        {
            if (this.Parent == null) return true;
            return this.Parent.Children[this.Parent.Children.Count - 1] == this;
        }

        public TreeNodeModel<T> GetPreviousSibling()
        {
            if (this.Parent == null || this.IsLeftMost()) return null;
            return this.Parent.Children[this.Parent.Children.IndexOf(this) - 1];
        }

        public TreeNodeModel<T> GetNextSibling()
        {
            if (this.Parent == null || this.IsRightMost()) return null;
            return this.Parent.Children[this.Parent.Children.IndexOf(this) + 1];
        }

        public TreeNodeModel<T> GetLeftMostSibling()
        {
            if (this.Parent == null) return null;
            if (this.IsLeftMost()) return this;
            return this.Parent.Children[0];
        }

        public TreeNodeModel<T> GetLeftMostChild()
        {
            if (this.Children.Count == 0) return null;

            return this.Children[0];
        }

        public TreeNodeModel<T> GetRightMostChild()
        {
            if (this.Children.Count == 0) return null;
            return this.Children[Children.Count - 1];
        }

        public override string ToString() => Item.ToString();
    }

    public static class TreeHelpers<T>
           where T : class
    {
        private static int nodeSize = 1;
        private static float siblingDistance = 0.0F;
        private static float treeDistance = 0.0F;

        public static void CalculateNodePositions(TreeNodeModel<T> rootNode)
        {
            // initialize node x, y, and mod values
            InitializeNodes(rootNode, 0);

            // assign initial X and Mod values for nodes
            CalculateInitialX(rootNode);

            // ensure no node is being drawn off screen
            CheckAllChildrenOnScreen(rootNode);

            // assign final X values to nodes
            CalculateFinalPositions(rootNode, 0);
        }

        // recusrively initialize x, y, and mod values of nodes
        private static void InitializeNodes(TreeNodeModel<T> node, int depth)
        {
            node.X = -1;
            node.Y = depth;
            node.Mod = 0;

            foreach (var child in node.Children)
                InitializeNodes(child, depth + 1);
        }

        private static void CalculateFinalPositions(TreeNodeModel<T> node, float modSum)
        {
            node.X += modSum;
            modSum += node.Mod;

            foreach (var child in node.Children)
                CalculateFinalPositions(child, modSum);

            if (node.Children.Count == 0)
            {
                node.Width = node.X;
                node.Height = node.Y;
            }
            else
            {
                node.Width = node.Children.OrderByDescending(p => p.Width).First().Width;
                node.Height = node.Children.OrderByDescending(p => p.Height).First().Height;
            }
        }

        private static void CalculateInitialX(TreeNodeModel<T> node)
        {
            foreach (var child in node.Children) CalculateInitialX(child);
            if (node.IsLeaf())
            {
                // if there is a previous sibling in this set, set X to prevous sibling + designated distance
                if (!node.IsLeftMost())
                    node.X = node.GetPreviousSibling().X + nodeSize + siblingDistance;
                else
                    // if this is the first node in a set, set X to 0
                    node.X = 0;
            }
            else if (node.Children.Count == 1)
            {
                if (node.IsLeftMost()) node.X = node.Children[0].X;
                else
                {
                    node.X = node.GetPreviousSibling().X + nodeSize + siblingDistance;
                    node.Mod = node.X - node.Children[0].X;
                }
            }
            else
            {
                var leftChild = node.GetLeftMostChild();
                var rightChild = node.GetRightMostChild();
                var mid = (leftChild.X + rightChild.X) / 2;

                if (node.IsLeftMost()) node.X = mid;
                else
                {
                    node.X = node.GetPreviousSibling().X + nodeSize + siblingDistance;
                    node.Mod = node.X - mid;
                }
            }

            if (node.Children.Count > 0 && !node.IsLeftMost()) CheckForConflicts(node);
        }

        private static void CheckForConflicts(TreeNodeModel<T> node)
        {
            var minDistance = treeDistance + nodeSize;
            var shiftValue = 0F;

            var nodeContour = new Dictionary<int, float>();
            GetLeftContour(node, 0, ref nodeContour);

            var sibling = node.GetLeftMostSibling();
            while (sibling != null && sibling != node)
            {
                var siblingContour = new Dictionary<int, float>();
                GetRightContour(sibling, 0, ref siblingContour);

                for (int level = node.Y + 1; level <= Math.Min(siblingContour.Keys.Max(), nodeContour.Keys.Max()); level++)
                {
                    var distance = nodeContour[level] - siblingContour[level];
                    if (distance + shiftValue < minDistance)
                    {
                        shiftValue = minDistance - distance;
                    }
                }

                if (shiftValue > 0)
                {
                    node.X += shiftValue;
                    node.Mod += shiftValue;

                    CenterNodesBetween(node, sibling);

                    shiftValue = 0;
                }

                sibling = sibling.GetNextSibling();
            }
        }

        private static void CenterNodesBetween(TreeNodeModel<T> leftNode, TreeNodeModel<T> rightNode)
        {
            var leftIndex = leftNode.Parent.Children.IndexOf(rightNode);
            var rightIndex = leftNode.Parent.Children.IndexOf(leftNode);

            var numNodesBetween = (rightIndex - leftIndex) - 1;

            if (numNodesBetween > 0)
            {
                var distanceBetweenNodes = (leftNode.X - rightNode.X) / (numNodesBetween + 1);

                int count = 1;
                for (int i = leftIndex + 1; i < rightIndex; i++)
                {
                    var middleNode = leftNode.Parent.Children[i];

                    var desiredX = rightNode.X + (distanceBetweenNodes * count);
                    var offset = desiredX - middleNode.X;
                    middleNode.X += offset;
                    middleNode.Mod += offset;

                    count++;
                }

                CheckForConflicts(leftNode);
            }
        }

        private static void CheckAllChildrenOnScreen(TreeNodeModel<T> node)
        {
            var nodeContour = new Dictionary<int, float>();
            GetLeftContour(node, 0, ref nodeContour);

            float shiftAmount = 0;
            foreach (var y in nodeContour.Keys)
            {
                if (nodeContour[y] + shiftAmount < 0)
                    shiftAmount = (nodeContour[y] * -1);
            }

            if (shiftAmount > 0)
            {
                node.X += shiftAmount;
                node.Mod += shiftAmount;
            }
        }

        private static void GetLeftContour(TreeNodeModel<T> node, float modSum, ref Dictionary<int, float> values)
        {
            if (!values.ContainsKey(node.Y))
                values.Add(node.Y, node.X + modSum);
            else
                values[node.Y] = Math.Min(values[node.Y], node.X + modSum);

            modSum += node.Mod;
            foreach (var child in node.Children)
            {
                GetLeftContour(child, modSum, ref values);
            }
        }

        private static void GetRightContour(TreeNodeModel<T> node, float modSum, ref Dictionary<int, float> values)
        {
            if (!values.ContainsKey(node.Y))
                values.Add(node.Y, node.X + modSum);
            else
                values[node.Y] = Math.Max(values[node.Y], node.X + modSum);

            modSum += node.Mod;
            foreach (var child in node.Children)
            {
                GetRightContour(child, modSum, ref values);
            }
        }
    }

}