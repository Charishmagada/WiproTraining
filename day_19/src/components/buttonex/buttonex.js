import React, {Component} from 'react';
const ButtonEx=()=>
{
  //to make below buttons work we have to write functions for each
  const aslesha = () => {
    alert("Hi I am aslesha");
  }

  const ayan = () => {
    alert("Hi i am ayan");
  }

  const arya = () => {
    alert("Hi I am arya");
  }
  return(
    <div>
      <input type="button" value="Aslesha" onClick={aslesha}/> 
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Ayan" onClick={ayan}/>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Arya" onClick={arya} />
      <hr/>
    </div>
  )
}
export default ButtonEx