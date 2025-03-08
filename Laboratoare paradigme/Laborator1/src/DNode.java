public interface DNode {
    int getValue();
    void setValue(int value);
    public void setNextNode(DoubleChainedNode n);
    public DoubleChainedNode getNextNode();
    public void setPrevNode(DoubleChainedNode prevNode);
    public DoubleChainedNode getPrevNode();
}
