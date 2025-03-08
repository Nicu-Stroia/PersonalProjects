import javax.swing.*;
import java.util.ArrayList;
import java.util.List;

public class SimpleChainedList {
    SimpleChainedNode head;

    public SimpleChainedList() {
        this.head = null;
    }

    public void addValue(int value){
        SimpleChainedNode newNode = new SimpleChainedNode(value);
        if(head == null){
            head = newNode;
        }
        else{
            SimpleChainedNode currentNode = head;
            while(currentNode.getNextNode() != null){
                currentNode = currentNode.getNextNode();
            }
            currentNode.setNextNode(newNode);
        }
    }

    public SimpleChainedNode getNodeByValue(int value) {
        SimpleChainedNode currentNode = head;
        while(currentNode != null){
            if(currentNode.getValue() == value){
                return currentNode;
            }
            currentNode = currentNode.getNextNode();
        }
        return null;
    }

    public boolean removeNodeByValue(int value){
        if(head == null){
            return false;
        }
        if(head.getValue() == value){
            head = head.getNextNode();
            return true;
        }
        SimpleChainedNode currentNode = head;
        while(currentNode.getNextNode() != null){
            if(currentNode.getNextNode().getValue() == value){
                currentNode.setNextNode(currentNode.getNextNode().getNextNode());
                return true;
            }
            currentNode = currentNode.getNextNode();
        }
        return false;
    }

    public void listNodes(){
        SimpleChainedNode currentNode = head;
        while(currentNode != null){
            System.out.print(currentNode.getValue() + " ");
            currentNode = currentNode.getNextNode();
        }
        System.out.println();
    }
}
