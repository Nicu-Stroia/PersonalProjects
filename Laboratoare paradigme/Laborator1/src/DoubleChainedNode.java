public class DoubleChainedNode implements DNode{
    int value;
    DoubleChainedNode nextNode;
    DoubleChainedNode prevNode;

    public DoubleChainedNode(int value) {
        this.value = value;
        this.nextNode = null;
        this.prevNode = null;
    }

    @Override
    public int getValue() {
        return value;
    }

    @Override
    public void setValue(int value) {
        this.value = value;
    }

    @Override
    public void setNextNode(DoubleChainedNode n){
        this.nextNode = n;
    }

    @Override
    public DoubleChainedNode getNextNode(){
        return this.nextNode;
    }

    @Override
    public void setPrevNode(DoubleChainedNode prevNode){
        this.prevNode = prevNode;
    }

    @Override
    public DoubleChainedNode getPrevNode(){
        return this.prevNode;
    }
}
