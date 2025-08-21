import { render, screen, fireEvent, waitFor } from '@testing-library/react';
import Calculation from "./calculation";

describe("Calculation Utility Functions to be Tested", () => {
    test("Add Two Numbers to be Tested", () => {
        expect(Calculation.sum(12,5)).toBe(17);
    })

    test("Sub Two Numbers to be Tested", () => {
        expect(Calculation.sub(12,5)).toBe(7);
    })

    test("Mult Two Numbers to be Tested", () => {
        expect(Calculation.mult(12,5)).toBe(60);
    })
});
