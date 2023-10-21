import React from 'react'
import Link from 'next/link';
import { FiPhoneCall } from 'react-icons/fi'
import { AiOutlineMail } from 'react-icons/ai'
import { BsHeartPulse } from 'react-icons/bs'

const Header = () => {
  return (
    <header id="main-header" className='flex flex-col bg-[#12325B]'>
        <section className='flex justify-between text-[14px]'>
            <section className='flex gap-4 px-[6.5rem]'>
                <div className=''>
                <FiPhoneCall className='inline' /> <span>+0885343008</span>
                </div>
                <div>
                    <AiOutlineMail className='inline' /> <span>lifelink@gmail.com</span>
                </div>
            </section>
            <section>
                <ul className='flex gap-4 px-[6.5rem]'>
                    <li><Link href="/about">About</Link></li>
                    <li>FAQ</li>
                    <li>Donate</li>
                    <li><span>EN</span> | <span>BG</span></li>
                </ul>
            </section>
      </section>
     <nav id='main-nav' className='flex justify-between h-[48px]
      items-center text-[1.05rem]'>
        <div className="px-10 flex items-center gap-[0.5rem]">
            <BsHeartPulse className='w-[25px] h-[25px]' /> <span className='text-[1.5rem]'>LifeLink</span>
        </div>
        <ul className='flex gap-5 items-center'>
            <li>Home</li>
            <li>Services</li>
            <li>Medics</li>
            <li>Hospitals</li>
            <li>For Kids</li>
            <li className='bg-gradient-to-r from-[#116BEB] to-[#0AA8EB] rounded-[35px] px-4 py-1'>Appointment</li>
        </ul>
        <div className='px-6'>
            <button className='px-4'>Log In</button>
            <button className='bg-white text-[#2E4493] rounded-[35px] px-4 py-1'>Sign Up</button>
        </div>
     </nav>
    </header>
  )
}

export default Header