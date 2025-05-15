import axios from 'axios';
import React, { useEffect, useState } from 'react'
import Card from './Card';

export default function Halak() {
    const [halak, setHalak] = useState([]);

    useEffect(() => {
      axios.get("https://halak.onrender.com/api/Halak")
      .then((data)=>{
        setHalak(data.data);
      })
    }, [])
    
  return (
    <div className='row'>
    {halak.map((h,index)=> <Card key={index} hal={h}/>)}
    </div>
  )
}
