import React, {Component,useState} from 'react';
import Menu from '../menu/menu';
const Sixth = () => {

  const [sname,setName] = useState('')

   const handleChange = event => {
        setName(event.target.value)
    }
//event.target.value is whatever the user typed.-predefined one
  return(
    <div>
      <Menu/>
      <form>
        <label>Please Enter Your Name  </label>
        <input type="text" name='sname' value={sname} onChange={handleChange} />
        <br/>
        Student Name is : {sname}
      </form>
    </div>
  )
}

export default Sixth;