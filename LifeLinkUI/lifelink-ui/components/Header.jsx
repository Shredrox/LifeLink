import React from 'react'
import Link from 'next/link'
import { FiPhoneCall } from 'react-icons/fi'
import { AiOutlineMail } from 'react-icons/ai'
import { BsHeartPulse } from 'react-icons/bs'
import Button from './Button'

const Header = () => {
  return (
    <header id="main-header" className='flex flex-col bg-primaryBlue text-white'>
        <section className='flex justify-between text-[14px]'>
            <section className='flex gap-4 px-[6.5rem]'>
                <div>
                    <FiPhoneCall className='inline' /> <span>+0885343008</span>
                </div>
                <div>
                    <AiOutlineMail className='inline' /> <span className='underline underline-offset-2'>lifelink@gmail.com</span>
                </div>
            </section>
            <section>
                <ul className='flex gap-4 px-[6.5rem]'>
                    <li><Link href="/about" className='hover:text-[#e6e8eb] active:text-[13px]'>About</Link></li>
                    <li>FAQ</li>
                    <li>Donate</li>
                    <li><span>EN</span> | <span>BG</span></li>
                </ul>
            </section>
        </section>
        <nav id='main-nav' className='flex justify-between h-[48px]
        items-center text-[1.05rem]'>
            <div className="px-10">
                <Link href='/' className='flex items-center gap-[0.5rem]' title='LifeLink'>
                    <BsHeartPulse className='w-[25px] h-[25px]' /> <span className='text-[1.5rem]'>LifeLink</span>
                </Link>
            </div>
            <ul className='flex gap-5 items-center w-[550px]'>
                <li className='hover:text-[#e6e8eb] active:text-[16px] w-[47px]'><Link href='/'>Home</Link></li>
                <li>Services</li>
                <li>Medics</li>
                <li>Hospitals</li>
                <li>For Kids</li>
                <li><Button content='Appointment' style='appointmentBtn btnEffects' /></li>
            </ul>
            <div className='px-6 w-[230px]'>
                <span className='px-4 hover:text-[#e6e8eb] active:text-[16px] w-[81px] inline-block'><Link href='/login'>Log In</Link></span>
                <Button content='Sign Up' style='signUpBtn btnEffects' path='/signup' />
            </div>
        </nav>
        <div className='relative bottom-0 left-0 w-[58%] h-[1px] bg-white'></div>
    </header>
  )
}

export default Header