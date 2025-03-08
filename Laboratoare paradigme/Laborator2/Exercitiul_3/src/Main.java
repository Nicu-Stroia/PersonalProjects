import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public class Main {
    public static void main(String[] args) {
        String filename = "E:\\Laboratoare paradigme\\Laborator2\\Exercitiul_3\\src\\input.txt";
        File file = new File(filename);
        Scanner sc = null;
        try{
            sc = new Scanner(file);
        }
        catch(FileNotFoundException e){
            System.out.println("File not found");
        }

        Student[] studenti = new Student[6];
        for(int i = 0; i <studenti.length; i++){
            studenti[i] = new Student(sc.next(), sc.next(), sc.nextLine());
        }

        Map<Student, Integer> students = new HashMap<Student, Integer>();
        for(Student s : studenti){
            students.put(s, students.getOrDefault(s, 0) + 1);
        }

        for(Map.Entry<Student, Integer> entry : students.entrySet()){
            System.out.println(entry.getKey() + " apare de " + entry.getValue() + " ori");
        }
    }

}