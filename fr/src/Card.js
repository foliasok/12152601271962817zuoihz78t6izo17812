import React from 'react'
import { useNavigate } from 'react-router-dom'

export default function Card({hal}) {
    const navigate = useNavigate();
  return (
    <div onClick={()=> navigate("/hal/"+hal.id)} className="card" style={{width: "18rem"}}>
    <div className="card-body">
        <h5 className="card-title">{hal.nev}</h5>
    </div>
    </div>
  )
}
