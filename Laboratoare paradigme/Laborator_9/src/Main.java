import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ArrayList<Person> people = new ArrayList<>();
        Person person1 = new Person("Alex", "Mihai", 20);
        Person person2 = new Person("Andreea", "Ioana", 20);
        Person person3 = new Person("Dan", "Cristian", 20);
        people.add(person1);
        people.add(person2);
        people.add(person3);
//        for (Person p : people) {
//            System.out.println(p);
//        }

//        write(people, "C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator_9\\src\\persoane.txt");
//        String locatie1;
//        Scanner sc = new Scanner(System.in);
//        locatie1 = sc.nextLine();
//        export(people, locatie1);

        //ExportToConsole exporter=new ExportToConsole();
//        ExportToFile exporter = new ExportToFile("C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator_9\\src\\persoane.txt");
//        export(people, exporter);

    }


//    public static void write(ArrayList<Person> people, String fisier) {
//        try (PrintWriter writer = new PrintWriter(new FileWriter(fisier))) {
//            for (Person person :people) {
//                writer.println(person.toString());
//            }
//        } catch (IOException e) {
//            e.printStackTrace();
//        }
//    }
//
//
//    public static void export(ArrayList<Person> people, String locatie) {
//        switch (locatie) {
//            case "Console":
//                for (Person person : people) {
//                    System.out.println(person.toString());
//                }
//                break;
//            case "File":
//                write(people, "C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator_9\\src\\persoane.txt");
//                break;
//        }
//    }

    public static void export(ArrayList<Person> people, Exporter exporter) {
        exporter.export(people);
    }

}
