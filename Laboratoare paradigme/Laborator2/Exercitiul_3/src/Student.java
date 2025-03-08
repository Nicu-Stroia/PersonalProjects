import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class Student {
    String nume;
    String prenume;
    String grupa;
    List<Integer> note;

    public Student(String nume, String prenume, String grupa) {
        this.nume = nume;
        this.prenume = prenume;
        this.grupa = grupa;
        note = new ArrayList();
    }

    public void getNume(String nume) {
        this.nume = nume;
    }

    public void getPrenume(String prenume) {
        this.prenume = prenume;
    }

    public void getGrupa(String grupa) {
        this.grupa = grupa;
    }

    public void adaugaNota(int nota) {
        note.add(nota);
    }

    public String toString(){
        return nume + " " + prenume + " " + grupa;
    }


    @Override
    public boolean equals(Object obj) {
        Student s = (Student) obj;
        if (this == obj) {
            return true;
        }
        return Objects.equals(this.nume, s.nume) &&
                Objects.equals(this.prenume, s.prenume);
    }


    @Override
    public int hashCode() {
        return Objects.hash(nume, prenume);
    }
}
