import axios from 'axios';
import React, { useEffect, useState } from 'react'

export default function Horgaszok() {
    const [horgaszok, setHorgaszok] = useState([]);

    useEffect(() => {
      axios.get("https://halak.onrender.com/api/Horgaszok")
      .then((data)=>{
        setHorgaszok(data.data);
        console.log(data.data)
      })
    }, [])
    
    const torles = (id) => {
        axios.delete("https://halak.onrender.com/api/Horgaszok/"+id)
        .then((res)=>{
            if(res.status == 204){
                alert("Sikeres törlés!");
            }
            else{
                console.error(res.statusText);
            }
        }
        )
    }

  return (
    <div className='row'>
        <ul className="list-group">
            {horgaszok.map((h,index)=> <li key={index} className="list-group-item">{h.nev} <button className='btn btn-danger' onClick={()=>  {
                if(window.confirm("Biztosan szeretnéd törölni?")){
                    torles(h.id);
                }
            }}><i className="bi bi-trash"></i></button></li>)}
        </ul>
    </div>
  )
}
