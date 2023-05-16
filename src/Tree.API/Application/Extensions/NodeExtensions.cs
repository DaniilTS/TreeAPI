using Domain.Entities;

namespace Application.Extensions
{
    public static class NodeExtensions
    {
        public static Node FindNode(this Node tree, Guid id)
        {
            if (tree.Id == id)
            {
                return tree;
            }
            else
            {
                foreach (var child in tree.Children)
                {
                    var res = FindNode(child, id);
                    if (res != null)
                        return res;
                }
            }

            return null;
        }

        public static bool HasANodeWithName(this Node node, string name)
        {
            return node.Children.Any(x => x.Name == name);
        }

        public static bool HasASiblingWithName(this Node node, string name)
        {
            if (node.Parent == null)
                return false;

            return HasANodeWithName(node.Parent, name);
        }
    }
}
