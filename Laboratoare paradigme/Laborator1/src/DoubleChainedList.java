public class DoubleChainedList {
    DoubleChainedNode head;

    public DoubleChainedList() {
        this.head = null;
    }

    public void addValue(int value) {
        DoubleChainedNode newNode = new DoubleChainedNode(value);
        if (head == null) {
            head = newNode;
        }
        else{
            DoubleChainedNode currentNode = head;
            while(currentNode.getNextNode() != null) {
                currentNode = currentNode.getNextNode();
            }
            currentNode.setNextNode(newNode);
            currentNode.setPrevNode(currentNode);
        }
    }

    public DoubleChainedNode getNodeByValue(int value) {
        DoubleChainedNode currentNode = head;
        while(currentNode != null) {
            if (currentNode.getValue() == value) {
                return currentNode;
            }
            currentNode = currentNode.getNextNode();
        }
        return null;
    }

    public boolean removeNodeByValue(int value) {
        if (head == null) {
            return false;
        }
        DoubleChainedNode currentNode = head;
        while(currentNode != null) {
            if (currentNode.getValue() == value) {
                if (currentNode==head) {
                    head = head.getNextNode();
                    if (head!=null) {
                        head.setPrevNode(null);
                    }
                }
                else{
                    DoubleChainedNode prevNode = currentNode.getPrevNode();
                    DoubleChainedNode nextNode = currentNode.getNextNode();
                    prevNode.setNextNode(nextNode);
                    if (nextNode!=null) {
                        nextNode.setPrevNode(prevNode);
                    }
                }
                return true;
            }
            currentNode = currentNode.getNextNode();
        }
        return false;
    }

    public void listNodes(){
        DoubleChainedNode currentNode = head;
        while(currentNode != null) {
            System.out.print(currentNode.getValue() + " ");
            currentNode = currentNode.getNextNode();
        }
        System.out.println();
    }
}
