import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) throws IOException {
        getPersoane();

        String filePath="C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator 5\\src\\DateSortate.txt";
        File dateSortate=new File(filePath);
        afisiareFisier(getPersoane(), dateSortate);
    }

    private static void afisiareFisier(List<Persoana> persoane, File dateSortate) throws IOException {
        FileWriter writer = new FileWriter(dateSortate);

        persoane.sort(Comparator.comparing(Persoana -> Persoana.getNume()));
        for(Persoana persoana : persoane){
            System.out.println(persoana.toString());
        }

        for(Persoana persoana : persoane) {
            writer.write(persoana.toString());
        }
    }

    private static List<Persoana> getPersoane() throws FileNotFoundException {
        Scanner sc;
        String filePath="C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Laborator 5\\src\\Date.txt";
        File file = new File(filePath);
        sc = new Scanner(file);
        String prenume;
        String nume;
        int varsta;
        List<Persoana> persoane = new ArrayList<>();
        for(int i = 0; i < 5;i++){
            prenume = sc.next();
            nume = sc.next();
            varsta = sc.nextInt();
            Persoana persoana = new Persoana(prenume, nume, varsta);
            persoane.add(persoana);
        }
        return persoane;
    }
}