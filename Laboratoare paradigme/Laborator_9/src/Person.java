import java.util.ArrayList;

public class Person {
    private String name;
    private String surname;
    private int age;

    public Person() {
        name=null;
        surname=null;
        age=0;
    }

    public Person(String name, String surname, int age) {
        this.name=name;
        this.surname=surname;
        this.age=age;
    }

    public String toString() {
        return name+" "+surname+" "+ age;
    }

}
