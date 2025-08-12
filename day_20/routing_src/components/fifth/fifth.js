import React, {Component,useState} from 'react';
import Menu from '../menu/menu';
const Fifth = () => {

  const [count,setCount] = useState(0)

  const increment = () => {
    setCount(count+1);
  }

  const decrement = () => {
    setCount(count-1);
  }

  return(
    <div>
      <Menu/>
      Count is : {count}
      <br/>
      <input type="button" value="Increment" onClick={increment} /> 
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Decrement" onClick={decrement} />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
  )
}

export default Fifth;