import axios from 'axios';
import React, { useState } from 'react'

export default function UjHorgasz() {
    const [nev, setNev] = useState("");
    const [eletkor, setEletkor] = useState("");

    const uj = () => {
        let horgasz = {
            nev: nev,
            eletkor: eletkor,
        }
        axios.post("https://halak.onrender.com/api/Horgaszok",horgasz)
        .then((res)=>{
            if(res.status == 201){
                alert("Sikeres hozzáadás.")
            }
            else{
                console.error(res.statusText);
            }
        })
    }
  return (
    <div>
        <form onSubmit={(e)=>{
            e.preventDefault();
            uj();
        }}>
        <div className="mb-3">
            <label htmlFor="nev" className="form-label">Név</label>
            <input value={nev} onChange={(e)=> setNev(e.target.value)} type="text" className="form-control" id="nev"/>
        </div>
        <div className="mb-3">
            <label htmlFor="eletkor" className="form-label">Életkor</label>
            <input value={eletkor} onChange={(e)=> setEletkor(e.target.value)} type="number" className="form-control" id="eletkor"/>
        </div>
        <button type="submit" className="btn btn-primary">Hozzáadás</button>
        </form>
    </div>
  )
}
