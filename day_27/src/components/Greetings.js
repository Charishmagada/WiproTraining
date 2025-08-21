const Greetings = () => {
    const morning = () =>{
        return "Good Morning!";
    }
    const afternoon = () => {
        return "Good Afternoon!";
    }

    const evening = () => {
        return "Good Evening!";
    }
    return(
        <div>
            {morning()} <br/>
        </div>
    )
}
export default Greetings;
