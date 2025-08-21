import React from 'react';
import { render, screen, fireEvent, waitFor } from '@testing-library/react';

import Greetings from './Greetings';

describe('Greeting Component Testing', () => {
    test("renders Good Morning message", () => {
        
        render(<Greetings />)
        const messageElement = screen.getByText("Good Morning!") 
        expect(messageElement).toBeInTheDocument();
    })
    test("does not render Good Afternoon by default", () => {
    render(<Greetings />);
    expect(screen.queryByText("Good Afternoon!")).toBeNull();
  });

  test("does not render Good Evening by default", () => {
    render(<Greetings />);
    expect(screen.queryByText("Good Evening!")).toBeNull();
  });
});
