import React from 'react'
import Link from 'next/link'
import { FiPhoneCall } from 'react-icons/fi'
import { AiOutlineMail } from 'react-icons/ai'
import { BsHeartPulse } from 'react-icons/bs'

const Footer = () => {

  return (
    <footer id='main-footer' className='bg-darkBlue text-white'>
       <div className='relative top-0 left-[10%] w-[80%] h-[1px] bg-white'></div>
       <section className='px-[9%] pt-[1.3rem]'>
          <section className='flex gap-6'>
              <Link href='/' className="flex items-center gap-[0.5rem]">
                  <BsHeartPulse className='w-[30px] h-[30px]' /> <span className='text-[2.25rem]'>LifeLink</span>
              </Link>
              <div className='flex flex-col justify-center text-[14px]'>
                <div>
                    <FiPhoneCall className='inline' /> <span>+0885343008</span>      
                </div>
                <div>
                    <AiOutlineMail className='inline' /> <span className='underline underline-offset-2'>lifelink@gmail.com</span>
                </div>
              </div>
          </section>
          <ul className='flex gap-5 items-center px-1 pt-2 text-[18px]'>
                <li className='hover:underline'><Link href='#'>Privacy Policy</Link></li>
                <li className='text-[14px]'>|</li>
                <li className='hover:underline'><Link href='#'>Terms and Conditions</Link></li>
                <li className='text-[14px]'>|</li>
                <li className='hover:underline'><Link href='#'>Do Not Share My Personal Information</Link></li>
                <li className='text-[14px]'>|</li>
                <li className='hover:underline'><Link href='#'>FAQ</Link></li>
                <li className='text-[14px]'>|</li>
                <li className='hover:underline'><Link href='#'>Donate</Link></li>
          </ul>
          <p className='px-1 pt-2 pb-3 text-[#ebedeb]'>
            &copy; {new Date().getFullYear()} LifeLink Healthcare Company. All rights reserved.
          </p>
        </section>
    </footer>
  )
}

export default Footer