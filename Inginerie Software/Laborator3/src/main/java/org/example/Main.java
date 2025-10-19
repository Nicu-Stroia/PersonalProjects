package org.example;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Student student1 = new Student("Stroia", "Nicu", 321);
        Student student2 = new Student("Stroia2", "Nicu2", 321);
        Student student3 = new Student("Stroia3", "Nicu3", 312);
        Student student4 = new Student("Stroia4", "Nicu4", 312);

        student1.generareNote();
        student2.generareNote();
        student3.generareNote();
        student4.generareNote();

        ArrayList<Student> students321 = new ArrayList<>();
        students321.add(student1);
        students321.add(student2);
        ArrayList<Student> students312 = new ArrayList<>();
        students312.add(student3);
        students312.add(student4);

        HashMap<Integer, ArrayList<Student>> grupe = new HashMap<Integer, ArrayList<Student>>();
        grupe.put(321, students321);
        grupe.put(312, students312);

        for (Map.Entry<Integer, ArrayList<Student>> entry : grupe.entrySet()) {
            System.out.println(entry.getKey());
            int promovati = 0;
            float mediaPerGrupa = 0;
            int nrStudenti = entry.getValue().size();
            for (Student student : entry.getValue()) {
                System.out.println(student.getNumePrenume() + " " + student.getMedia(student.getNote()));
                mediaPerGrupa += student.getMedia(student.getNote());
                if(student.getMedia(student.getNote()) >= 5){
                    promovati++;
                }
            }
            float rataPromovabilitate = ((float)promovati / nrStudenti) * 100;
            System.out.println("Media per grupa "+ mediaPerGrupa/nrStudenti);
            System.out.println(promovati + " promovati");
            System.out.println(rataPromovabilitate + "% rata promovabilitate");
        }
    }
}