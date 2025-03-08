public interface INode {
    int getValue();
    void setValue(int value);
    public void setNextNode(SimpleChainedNode n);
    public SimpleChainedNode getNextNode();
}
