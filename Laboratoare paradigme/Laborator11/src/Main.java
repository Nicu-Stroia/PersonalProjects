import java.util.ArrayList;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ExportConfig config1 = new ExportConfig("1.txt");
        ExportConfig config2 = new ExportConfig("2.txt");
        ArrayList<Person> persons = new ArrayList<>();
        persons.add(new Person("Ana"));
        Exporter exporter1 = new Exporter(config1, persons);
        persons.add(new Person("Mihai"));
        Exporter exporter2 = new Exporter(config2, persons);
        exporter1.export();
        exporter2.export();
    }
}