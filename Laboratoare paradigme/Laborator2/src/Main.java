import java.util.*;
public class Main {
    public static void main(String[] args) {
        /*List<Integer> x = new ArrayList();
        List<Integer> y = new ArrayList();
        List<Integer> xPlusY = new ArrayList();
        Set<Integer> zSet = new TreeSet();
        List<Integer> xMinusY = new ArrayList();
        int p = 4;
        List<Integer> xPlusYLimitedByP = new ArrayList();
        Random random = new Random();
        for (int i = 0; i <5 ;i++) {
            x.add(random.nextInt(11));
        }
        for(int i = 0; i < 7; i++) {
            y.add(random.nextInt(11));
        }
        Collections.sort(x);
        Collections.sort(y);
        xPlusY.addAll(x);
        xPlusY.addAll(y);
        zSet.addAll(y);
        zSet.retainAll(x);
        xMinusY.addAll(x);
        xMinusY.removeAll(y);
        for(int number:xPlusY){
            if (number <= p){
                xPlusYLimitedByP.add(number);
            }
        }
         */

        Random random = new Random();
        Student[] studenti = new Student[3];
        String nume;
        String prenume;
        String grupa;
        Scanner sc = new Scanner(System.in);
        for(int i = 0; i < 3;i++){
            nume = sc.nextLine();
            prenume = sc.nextLine();
            grupa = sc.nextLine();
            studenti[i] = new Student(nume, prenume, grupa);
        }
        for(int i = 0; i < 3;i++){
            for (int j = 1; j <=5;j++){
                studenti[i].adaugaNota(random.nextInt(4, 11));
            }
        }
        for(int i = 0; i < 3;i++){
            studenti[0].compareTo(studenti[i]);
        }
        //Arrays.sort(studenti);

        List<Double> medii = new ArrayList<>();
        for(int i = 0; i < 3;i++){
            if(studenti[i].media()>=4.5) {
                medii.add(studenti[i].media());
            }
        }
        /*Collections.sort(medii, Collections.reverseOrder());
        for(int i = 0; i < 3;i++){
            System.out.println(studenti[i].toString() + " " + medii.get(i));
        }*/

        List<Integer> restnate = new ArrayList<>();
        for(int i = 0; i < 3;i++){
            restnate.add(studenti[i].numarRestante());
        }
        Collections.sort(restnate);
        for(int i = 0; i < 3;i++){
            System.out.println(studenti[i].toString() + " " + restnate.get(i));
        }
    }
}