import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Student implements Comparable{
    private String nume;
    private String prenume;
    private String grupa;
    private List<Integer> note;

    public Student(String nume, String prenume, String grupa) {
        this.nume = nume;
        this.prenume = prenume;
        this.grupa = grupa;
        note = new ArrayList<Integer>();
    }

    public String getNume() {
        return nume;
    }
    public String getPrenume() {
        return prenume;
    }
    public String getGrupa() {
        return grupa;
    }
    public void adaugaNota(int nota){
        note.add(nota);
    }
    public double media() {
        double sum = 0;
        for (int n : note) {
            sum += n;
        }
        return sum / note.size();
    }
    public int numarRestante() {
        int count = 0;
        for (int n : note) {
            if (n == 4) {
                count++;
            }
        }
        return count;
    }

    @Override
    public int compareTo(Object o) {
        Student s = (Student) o;
        return this.grupa.compareTo(s.grupa);
    }

    public String toString() {
        return nume + " " + prenume + " " + grupa;
    }
}
