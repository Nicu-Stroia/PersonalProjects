import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        ArrayList<Sali> sali = new ArrayList<>();

        Scanner sc = new Scanner(System.in);
        sc = null;

        try {
            sc = new Scanner(new File("C:\\ProjectsGit\\PersonalProjects\\Laboratoare paradigme\\Stroia Nicolae Aurelian\\src\\sali.txt"));
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }

        while (sc.hasNextLine()) {
            sali.add(new Sali(sc.next(), sc.next(), sc.next(), sc.nextInt()));
        }


        for(Sali sala: sali){
            Sali etajSala = new Sali();
            etajSala.etaj = "parter";
            if(etajSala.equals(sala)){
                System.out.println(sala.toString());
            }
        }

        for(Sali sala: sali){
            Sali codSala = new Sali();
            codSala.etaj = "cod";
        }

        Sali sala2 = new Sali();
        sala2.cod = "IM320";
        Sali sala1 = new Sali();
        sala1.cod = "IM321";
        int numar1 = 17;
        int numar2 = 2;
        for(Sali sala: sali) {
            if(numar1<=30){
                if(sala1.equals(sala)){
                    sala.numarCalculatoare += numar1;
                    System.out.println(sala.toString());
                }
            }
            if(numar2<=30){
                if(sala2.equals(sala)){
                    sala.numarCalculatoare += numar2;
                    System.out.println(sala.toString());
                }
            }
        }


    }
}