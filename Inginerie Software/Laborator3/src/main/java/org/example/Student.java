package org.example;

import java.util.ArrayList;
import java.util.Random;

public class Student {
    private String nume;
    private String prenume;
    private int grupa;
    private ArrayList<Integer> note = new ArrayList<>();

    public Student(String nume, String prenume, int grupa) {
        this.nume = nume;
        this.prenume = prenume;
        this.grupa = grupa;
    }

    public double getMedia(ArrayList<Integer> note) {
        double media = 0;
        for (int i = 0; i < note.size(); i++) {
            media = media + note.get(i);
        }
        return media/note.size();
    }

    public String getNumePrenume() {
        return nume + " " + prenume;
    }

    public ArrayList<Integer> generareNote(){
        Random rand = new Random();
        for (int i = 0; i < 5; i++) {
            int nota = rand.nextInt(11);
            note.add(nota);
        }
        return note;
    }

    public ArrayList<Integer> getNote(){
        return note;
    }

    public int getGrupa() {
        return grupa;
    }

    @Override
    public String toString() {
        return nume + " " + prenume + " " + grupa;
    }
}
