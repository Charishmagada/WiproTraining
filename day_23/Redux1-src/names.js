import { useDispatch, useSelector } from "react-redux";
import { arya, aslesha, river } from "./action";

const Names = () => {
    // Access the sname value from the Redux store
    const sname = useSelector( (state) => state.sname)
    // Get the dispatch function from Redux
    const dispatch = useDispatch();
    return (
        <div>
            <h3>Student Name is : {sname}</h3>
            <input type="button" value="aslesha" onClick={() => dispatch(aslesha())} />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="arya" onClick={() => dispatch(arya())} /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="river" onClick={() => dispatch(river())} />
        </div>
    )
}

export default Names;