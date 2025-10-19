package org.example;

import java.util.ArrayList;

public class Student {
    private String nume;
    private String prenume;
    private int grupa;
    private ArrayList<Integer> note = new ArrayList<>();

    public Student(String nume, String prenume, int grupa, ArrayList<Integer> note) {
        this.nume = nume;
        this.prenume = prenume;
        this.grupa = grupa;
        this.note = note;
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
