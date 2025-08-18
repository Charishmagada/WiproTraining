const initialState = {
    sname : ''
}
const NameReducer = (state = initialState, action) => {
    switch(action.type) {
        case 'aslesha' :
            return {...state,sname:'Hi,I am Aslesha'};
        case 'arya' : 
            return {...state,sname:'Hi,I am Arya'};
        case 'river' : 
            return {...state,sname:'Hi,I am River'}
        default : 
            return state;
    }
}
export default NameReducer;
