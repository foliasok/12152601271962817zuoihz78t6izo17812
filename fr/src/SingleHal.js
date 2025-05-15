import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

export default function SingleHal() {
    const { id } = useParams();
    const [hal, setHal] = useState({});
    const navigate = useNavigate();
    useEffect(() => {
      axios.get("https://halak.onrender.com/api/Halak/"+id)
      .then((data)=>{
        setHal(data.data);
      })
    }, [])
    
  return (
    <div className="card" style={{width: "18rem"}}>
    <img src={hal.kep} className="card-img-top" alt="..."/>
    <div className="card-body">
        <h5 className="card-title">{hal.nev}</h5>
        <p className="card-text">Faj: {hal.faj} <br/> Méret: {hal.meretCm} cm</p>
        <a className="btn btn-primary" onClick={()=> navigate("/")}>Vissza a halakhoz</a>
    </div>
    </div>
  )
}
