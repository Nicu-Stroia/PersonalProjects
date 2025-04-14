package org.example.logic;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class CalculatorTest {

    @Test
    void add_AddsValueToTheResult() {
        Calculator calculator = new Calculator();

        calculator.add(5);

        assertEquals(5, calculator.getRezultat());
    }

    @Test
    void add_AddsNegativeValueToTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.add(-2);

        assertEquals(3, calculator.getRezultat());
    }

    @Test
    void subtract_SubtractsValueFromTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.substract(2);

        assertEquals(3, calculator.getRezultat());
    }

    @Test
    void subtract_SubstractsNegativeValueFromTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.substract(-2);

        assertEquals(7, calculator.getRezultat());
    }

    @Test
    void multiply_MultiplysValueToTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.multiply(2);

        assertEquals(10, calculator.getRezultat());
    }

    @Test
    void multiply_MultiplysNegativeValueToTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.multiply(-2);

        assertEquals(-10, calculator.getRezultat());
    }

    @Test
    void multiply_MultiplyWithZeroToTheResult() {
        Calculator calculator = new Calculator(5);

        calculator.multiply(0);

        assertEquals(0, calculator.getRezultat());
    }

    @Test
    void divide_DividesValueToTheResult() {
        Calculator calculator = new Calculator(10);

        calculator.divide(2);

        assertEquals(5, calculator.getRezultat());
    }

    @Test
    void divide_DividesNegativeValueToTheResult() {
        Calculator calculator = new Calculator(10);

        calculator.divide(-2);

        assertEquals(-5, calculator.getRezultat());
    }

    @Test
    void divide_Exception() {
        Calculator calculator = new Calculator(10);

        Exception exception = assertThrows(ArithmeticException.class, () -> calculator.divide(0));
        assertEquals("Cannot divide by zero", exception.getMessage());
    }


}