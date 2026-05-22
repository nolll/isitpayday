import { useState } from "react";
import type { Country } from "@/types/Country";

interface Props {
  value: string;
  countries: Country[];
  onChange: (value: string) => void;
}

export default function CountryForm({ value, countries, onChange }: Props) {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const countryName = countries.find((c) => c.id === value)?.name ?? "";

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setIsFormVisible(false);
    onChange(event.target.value);
  };

  return (
    <div>
      <h3>Country</h3>
      <div className="country-info">
        <p style={{ display: isFormVisible ? "" : "none" }}>
          <select value={value} onChange={handleChange}>
            {countries.map((c) => (
              <option value={c.id} key={c.id}>
                {c.name}
              </option>
            ))}
          </select>
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              setIsFormVisible(false);
            }}
          >
            Cancel
          </a>
        </p>
        <p style={{ display: isFormVisible ? "none" : "" }}>
          {countryName}{" "}
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              setIsFormVisible(true);
            }}
          >
            Change
          </a>
        </p>
      </div>
    </div>
  );
}
