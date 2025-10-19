package org.example;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ArrayList<Integer> noteStudent1 = new ArrayList<>();
        ArrayList<Integer> noteStudent2 = new ArrayList<>();
        noteStudent1.add(5);
        noteStudent1.add(10);
        noteStudent1.add(6);
        noteStudent1.add(2);
        noteStudent1.add(9);
        noteStudent2.add(9);
        noteStudent2.add(10);
        noteStudent2.add(3);
        noteStudent2.add(7);
        noteStudent2.add(10);
        Student student1 = new Student("Stroia", "Nicu", 321, noteStudent1);
        Student student2 = new Student("Stroia2", "Nicu2", 321, noteStudent2);

        ArrayList<Student> students = new ArrayList<>();
        students.add(student1);
        students.add(student2);

        HashMap<Integer, ArrayList<Student>> grupe = new HashMap<Integer, ArrayList<Student>>();
        grupe.put(321, students);

        int promovati = 0;

        for (Map.Entry<Integer, ArrayList<Student>> entry : grupe.entrySet()) {
            System.out.println(entry.getKey());
            for (Student student : entry.getValue()) {
                System.out.println(student.getNumePrenume() + " " + student.getMedia(student.getNote()));
                if(student.getMedia(student.getNote()) >= 5){
                    promovati++;
                }
            }
            System.out.println(promovati + " promovati");
        }
    }
}