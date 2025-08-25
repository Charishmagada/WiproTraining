const AuthHeader = () => {
    const token = localStorage.getItem("token");
   //   alert(token);
     if (token) {
         //  alert("Success")
       return { Authorization: 'Bearer ' + token };
    } else {
      return {};
}
}
export default AuthHeader
