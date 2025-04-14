package org.example.logic;

public class Calculator {
    protected double x;

    public Calculator() {
        this.x = 0;
    }

    public Calculator(double x) {
        this.x = x;
    }

    public Calculator add(double numar){
        x += numar;
        return this;
    }

    public Calculator substract(double numar){
        x -= numar;
        return this;
    }

    public Calculator multiply(double numar){
        x *= numar;
        return this;
    }

    public Calculator divide(double numar){
        if(numar==0){
            throw new ArithmeticException("Cannot divide by zero");
        }
        x/=numar;
        return this;
    }

    public Calculator squareRoot(){
        if(x<=-1){
            throw new ArithmeticException("Nu se poate face radical din numere negative");
        }
        x=Math.sqrt(x);
        return this;
    }

    public Calculator power(int numar){
        if(x<=-1){
            x = 1/(Math.pow(x,numar));
        }
        x = Math.pow(x,numar);
        return this;
    }

    public double getRezultat() {
        return x;
    }
}
