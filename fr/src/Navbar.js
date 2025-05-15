import React from 'react'
import { Link } from 'react-router-dom'

export default function Navbar() {
  return (
    <div>
        <ul className="nav justify-content-center">
        <li className="nav-item">
            <p className="nav-link"><Link to={"/"}>Halak</Link></p>
        </li>
        <li className="nav-item">
            <p className="nav-link"><Link to={"/horgaszok"}>Horgászok</Link></p>
        </li>
        <li className="nav-item">
            <p className="nav-link"><Link to={"/balaton"}>Balaton</Link></p>
        </li>
        <li className="nav-item">
            <p className="nav-link"><Link to={"/ujhorgasz"}>Új Horgász</Link></p>
        </li>
        </ul>
    </div>
  )
}
