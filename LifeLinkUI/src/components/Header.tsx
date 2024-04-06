import { Link } from 'react-router-dom'
import { FiPhoneCall } from 'react-icons/fi'
import { AiOutlineMail } from 'react-icons/ai'
import Navbar from "./Navbar";

const Header = () => {
  return (
    <header id="main-header" className='flex flex-col bg-primaryBlue text-white fixed w-full z-[2]'>
      <section className='flex justify-between text-[14px] mb-2'>
        <section className='flex gap-4 px-[6.5rem]'>
          <span>
            <FiPhoneCall className='inline' /> <span>+0885343008</span>
          </span>
          <span>
            <AiOutlineMail className='inline' /> <span className='underline underline-offset-2'>lifelink@gmail.com</span>
          </span>
        </section>
        <section>
          <ul className='flex gap-4 px-[6.5rem]'>
            <li>
              <Link to="/about" className='hover:text-[#e6e8eb]'>About</Link>
            </li>
            <li>FAQ</li>
            <li>Donate</li>
            <li>
              <span>EN</span> | <span>BG</span>
            </li>
          </ul>
        </section>
      </section>
      <Navbar />
    </header>
  );
}

export default Header;