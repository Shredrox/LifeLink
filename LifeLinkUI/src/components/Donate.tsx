import Button from './Button'
import DonateLogo from '../assets/images/donate.png'

const Donate = () => {
  return (
    <section className='bg-primaryBlue text-white h-[270px] flex items-center justify-center'>
      <section className='flex justify-center gap-[6rem] mb-3'>
        <div className='flex items-center'>
          <img src={DonateLogo} alt='Donate Logo' width={200} height={95} />
          <p className='text-[2.1rem] font-bold w-[330px] text-center'>Your gift holds great power – donate today!</p>
        </div>
        <div className='flex items-center w-[560px] mb-4'>
          <p className='w-[440px] text-[1.2rem]'>
            Contribute a tax-deductible donation and join the forefront of transformative healthcare, 
            where connections and compassion are reshaping the field of medicine.
          </p>
          <Button style='donateBtn mb-14' content='Donate' />
        </div>
      </section>
    </section>
  )
}

export default Donate
