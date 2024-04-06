import { BsHeartPulse } from "react-icons/bs";
import { Link } from "react-router-dom";
import Button from "./Button";

const Navbar = () => {
  return (
    <nav id='main-nav' className='flex justify-between items-center text-[1.05rem] mb-2'>
      <div className="px-10">
        <Link to='/' className='flex items-center gap-[0.5rem]' title='LifeLink | Home'>
          <BsHeartPulse size={25} /> <span className='text-[1.5rem]'>LifeLink</span>
        </Link>
      </div>
      <ul className='flex gap-5 items-center'>
        <li className='hover:text-[#e6e8eb]'>
          <Link to='/'>Home</Link>
        </li>
        <li>Services</li>
        <li>Medics</li>
        <li>For Kids</li>
        <li>
          <Button content='Appointment' style='appointmentBtn btnEffects' />
        </li>
      </ul>
      <div className='px-10 flex gap-x-6'>
        <Link to='/login' className="hover:text-[#e6e8eb]">
          Log In
        </Link>
        <Button content='Sign Up' style='signUpBtn btnEffects' path='/signup' />
      </div>
    </nav>
  );
}

export default Navbar;
