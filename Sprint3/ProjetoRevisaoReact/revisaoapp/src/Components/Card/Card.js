export function Card({title}) {
    return(
        <div className="card">
            <button className="buttonCheck">{/* icon */}</button>
            <p className="cardDescription">{title}</p>
            <button className="buttonDelete">{/* icon */}</button>
            <button className="buttonEdit">{/* icon */}</button>
        </div>
    )
}