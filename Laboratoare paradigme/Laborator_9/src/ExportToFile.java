import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class ExportToFile implements Exporter{
    private String fileName;
    public ExportToFile(String fileName) {
        this.fileName = fileName;
    }

    @Override
    public void export(ArrayList<Person> persons) {
        try (PrintWriter writer = new PrintWriter(new FileWriter(fileName))) {
            for (Person person :persons) {
                writer.println(person.toString());
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}
