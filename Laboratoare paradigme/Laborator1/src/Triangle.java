public class Triangle extends Form{
    private float height;
    private float base;

    public Triangle(){
        super();
        height = 0;
        base = 0;
    }
    public Triangle(float height, float base, String color){
        super(color);
        this.height = height;
        this.base = base;
    }

    @Override
    public float getArea(){
        return (height * base)/2;
    }

    @Override
    public String toString(){
        return super.toString();
    }

    public boolean equals(Object obj) {
        return super.equals(obj);
    }
}
