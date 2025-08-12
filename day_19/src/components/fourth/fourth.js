//useState isn’t just about storing data - it’s about telling React to refresh the UI 
// whenever that data changes. Without it, the UI stays frozen.
import React, {Component,useState} from 'react';
const Fourth=()=>
{
  const[name,setName]=useState('')
  const rustyn = () => {
    setName("Hi I am Rustyn");
  }

  const river = () => {
    setName("Hi I am River");
  }

  const jette = () => {
    setName("Hi I am Jette");
  }

  return(
    <div>
      <input type="button" value="Rustyn" onClick={rustyn} />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="River" onClick={river} /> 
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Jette" onClick={jette} />
      <hr/>
      Name is : <b>{name}</b>
    </div>
  )
}

export default Fourth