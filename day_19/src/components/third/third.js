import React, {Component} from 'react';
const Third=(props)=>
{
  return(
    <div>
      First Name:<b>{props.firstName}</b><br/>
      Last Name:<b>{props.lastName}</b><br/>
      Company:<b>{props.company}</b><br/>
      <hr/>
    </div> 
  )
}
export default Third