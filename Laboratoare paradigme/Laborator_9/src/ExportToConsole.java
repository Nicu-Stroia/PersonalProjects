import java.util.ArrayList;

public class ExportToConsole implements Exporter{
    @Override
    public void export(ArrayList<Person> persons) {
        for (Person p : persons) {
            System.out.println(p);
        }
    }
}
