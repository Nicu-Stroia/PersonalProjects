import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class Exporter{
    final ExportConfig exportConfig;
    final ArrayList<Person> persons;

    public Exporter(ExportConfig exportConfig, ArrayList<Person> persons) {
        this.exportConfig = exportConfig;
        this.persons = new ArrayList<>(persons);
    }

    public void export(){
        try (PrintWriter writer = new PrintWriter(new FileWriter(exportConfig.fileName))) {
            for (Person person :persons) {
                writer.println(person.toString());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
