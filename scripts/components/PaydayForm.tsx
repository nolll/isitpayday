import { useState, useMemo } from 'react';
import { frequencyTypes } from '@/frequencyTypes';
import { formatNth } from '@/nth-formatter';
import { getWeekdayName } from '@/weekdays';
import type { Payday } from '@/types/Payday';

interface Props {
  value: number;
  frequencyId: string;
  onChange: (value: number) => void;
}

const format = (frequencyId: string, payday: number): string => {
  if (frequencyId === frequencyTypes.weekly) return getWeekdayName(payday);
  return formatNth(payday);
};

const buildPaydays = (frequencyId: string, upperBound: number): Payday[] => {
  const result: Payday[] = [];
  for (let i = 1; i <= upperBound; i++) {
    result.push({ id: i, name: format(frequencyId, i) });
  }
  return result;
};

export const PaydayForm = ({ value, frequencyId, onChange }: Props) => {
  const [isFormVisible, setIsFormVisible] = useState(false);

  const paydayName = format(frequencyId, value);

  const paydays = useMemo(() => {
    const upperBound = frequencyId === frequencyTypes.weekly ? 7 : 31;
    return buildPaydays(frequencyId, upperBound);
  }, [frequencyId]);

  const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setIsFormVisible(false);
    onChange(parseInt(event.target.value));
  };

  return (
    <div>
      <h3>Payday</h3>
      <div className="payday-info">
        <p style={{ display: isFormVisible ? '' : 'none' }}>
          <select value={value} onChange={handleChange}>
            {paydays.map((p) => (
              <option value={p.id} key={p.id}>
                {p.name}
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
        <p style={{ display: isFormVisible ? 'none' : '' }}>
          {paydayName}{' '}
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
};
