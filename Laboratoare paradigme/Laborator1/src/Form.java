public class Form {
    private String color;

    public Form(){
        color = "white";
    }
    public  Form(String color){
        this.color = color;
    }

    public float getArea(){
        return 0;
    }

    public String toString(){
        return "This form has the color " + color;
    }
}
