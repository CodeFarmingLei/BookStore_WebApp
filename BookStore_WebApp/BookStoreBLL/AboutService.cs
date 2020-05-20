using BookStore.DAL;
using BookStore.Model;

namespace BookStore.BLL
{
    public class AboutService
    {
        private AboutManager dal = new AboutManager();

        public int Add(About model)
        {
            return dal.Add(model);
        }


        public int Edit(About model)
        {
            return dal.Edit(model);
        }

        public About GetAboutById(int id)
        {
            return dal.GetAboutById(id);
        }
    }
}