namespace UnitTestDemoWebAPI.Models.Services
{
    public class HardwareComponentServices : IHardwareComponentServices
    {

        private List<HardwareComponent> _components = new List<HardwareComponent>()
        {
            new HardwareComponent(){ Id = 1, Name = "RAM", Brand = "Corsair"},
            new HardwareComponent(){ Id = 2, Name = "Keyboard", Brand = "Genius"}
        };
        public IEnumerable<HardwareComponent> Get() => _components;
        public HardwareComponent? Get(int id)
        {
            return _components.FirstOrDefault(component => component.Id == id);
        }
    }
}
