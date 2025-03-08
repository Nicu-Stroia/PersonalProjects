public class SimpleChainedNode implements INode {
    int value;
    SimpleChainedNode nextNode;

    public SimpleChainedNode(int value) {
        this.value = value;
        this.nextNode = null;
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
    public void setNextNode(SimpleChainedNode n){
        this.nextNode = n;
    }

    @Override
    public SimpleChainedNode getNextNode() {
        return nextNode;
    }
}
