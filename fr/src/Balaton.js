import axios from 'axios';
import React, { useEffect, useState } from 'react'

export default function Balaton() {
    const [balaton, setBalaton] = useState({});
    useEffect(() => {
      axios.get("https://halak.onrender.com/api/Tavak/1")
      .then((data)=>{
        setBalaton(data.data);
        console.log(data.data)
      })
    }, [])
    
  return (
    <div className="card" style={{width: "18rem"}}>
    <img src={balaton.kep} className="card-img-top" alt="..."/>
    <div className="card-body">
        <h5 className="card-title">{balaton.nev}</h5>
        <p className="card-text">Helyszín: {balaton.helyszin}</p>
    </div>
    </div>
  )
}
